﻿using System;
using System.Buffers;
using System.IO;
using System.Text;
using System.Threading;
using Omnix.Base;
using Omnix.Serialization.RocketPack.Internal;

namespace Omnix.Serialization.RocketPack
{
    /// <summary>
    /// RocketPackフォーマットのシリアライズ機能を提供します。
    /// </summary>
    public sealed class RocketPackWriter
    {
        private IBufferWriter<byte> _bufferWriter;
        private BufferPool _bufferPool;

        private static readonly ThreadLocal<Encoding> _encoding = new ThreadLocal<Encoding>(() => new UTF8Encoding(false));

        public RocketPackWriter(IBufferWriter<byte> bufferWriter, BufferPool bufferPool)
        {
            _bufferWriter = bufferWriter;
            _bufferPool = bufferPool;
        }

        public void Write(string value)
        {
            using (var memoryOwner = _bufferPool.Rent(_encoding.Value.GetMaxByteCount(value.Length)))
            {
                int length = _encoding.Value.GetBytes(value.AsSpan(), memoryOwner.Memory.Span);
                Varint.SetUInt64((uint)length, _bufferWriter);

                _bufferWriter.Write(memoryOwner.Memory.Span.Slice(0, length));
            }
        }

        public void Write(ReadOnlySpan<byte> value)
        {
            Varint.SetUInt64((uint)value.Length, _bufferWriter);
            _bufferWriter.Write(value);
        }

        public void Write(Timestamp value)
        {
            this.Write((long)value.Seconds);
            this.Write((ulong)value.Nanos);
        }

        public void Write(bool value)
        {
            this.Write((ulong)(!value ? (byte)0x00 : (byte)0x01));
        }

        public void Write(long value)
        {
            Varint.SetInt64(value, _bufferWriter);
        }

        public void Write(ulong value)
        {
            Varint.SetUInt64(value, _bufferWriter);
        }

        public unsafe void Write(float value)
        {
            var f = new Float32Bits(value);
            f.CopyTo(_bufferWriter.GetSpan(4));
            _bufferWriter.Advance(4);
        }

        public unsafe void Write(double value)
        {
            var f = new Float64Bits(value);
            f.CopyTo(_bufferWriter.GetSpan(8));
            _bufferWriter.Advance(8);
        }
    }
}