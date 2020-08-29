
#nullable enable

namespace Omnius.Core.RocketPack.Remoting.Tests.Internal
{

    internal sealed partial class RpcParam : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam>.Formatter;
        public static global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam>.Empty;

        static RpcParam()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam>.Empty = new global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam(0);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public RpcParam(int p1)
        {
            this.P1 = p1;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (p1 != default) ___h.Add(p1.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public int P1 { get; }

        public static global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam? left, global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam? left, global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam)) return false;
            return this.Equals((global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam)other);
        }
        public bool Equals(global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.P1 != target.P1) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.P1 != 0)
                {
                    w.Write((uint)1);
                    w.Write(value.P1);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                int p_p1 = 0;

                for (;;)
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_p1 = r.GetInt32();
                                break;
                            }
                    }
                }

                return new global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcParam(p_p1);
            }
        }
    }
    internal sealed partial class RpcResult : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult>.Formatter;
        public static global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult>.Empty;

        static RpcResult()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult>.Empty = new global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult(0);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public RpcResult(int r1)
        {
            this.R1 = r1;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (r1 != default) ___h.Add(r1.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public int R1 { get; }

        public static global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult? left, global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult? left, global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult)) return false;
            return this.Equals((global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult)other);
        }
        public bool Equals(global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.R1 != target.R1) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.R1 != 0)
                {
                    w.Write((uint)1);
                    w.Write(value.R1);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                int p_r1 = 0;

                for (;;)
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_r1 = r.GetInt32();
                                break;
                            }
                    }
                }

                return new global::Omnius.Core.RocketPack.Remoting.Tests.Internal.RpcResult(p_r1);
            }
        }
    }


}
