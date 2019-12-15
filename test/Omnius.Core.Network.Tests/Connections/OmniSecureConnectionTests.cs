using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Omnius.Core;
using Omnius.Core.Network.Caps;
using Omnius.Core.Network.Connections.Secure;
using Xunit;

namespace Omnius.Core.Network.Connections
{
    public class OmniSecureConnectionTests
    {
        [Fact]
        public async Task RandomSendAndReceiveTest()
        {
            var random = new Random();

            var caseList = new List<int>();
            caseList.AddRange(Enumerable.Range(1, 32));
            caseList.AddRange(new int[] { 100, 1000, 10000, 1024 * 1024 });

            var (socket1, socket2) = SocketHelpers.GetSockets();

            var options = new OmniNonblockingConnectionOptions()
            {
                MaxReceiveByteCount = 1024 * 1024 * 256,
                MaxSendByteCount = 1024 * 1024 * 256,
                BufferPool = BufferPool<byte>.Shared,
            };

            using (var baseConnection1 = new OmniNonblockingConnection(new SocketCap(socket1, false), options))
            using (var baseConnection2 = new OmniNonblockingConnection(new SocketCap(socket2, false), options))
            using (var connection1 = new OmniSecureConnection(baseConnection1, new OmniSecureConnectionOptions() { Type = OmniSecureConnectionType.Connected }))
            using (var connection2 = new OmniSecureConnection(baseConnection2, new OmniSecureConnectionOptions() { Type = OmniSecureConnectionType.Accepted }))
            {
                // ハンドシェイクを行う
                {
                    var valueTask1 = connection1.Handshake();
                    var valueTask2 = connection2.Handshake();

                    var stopwatch = Stopwatch.StartNew();

                    while (!valueTask1.IsCompleted || !valueTask2.IsCompleted)
                    {
                        if (stopwatch.Elapsed.TotalSeconds > 60)
                        {
                            throw new TimeoutException("Handshake");
                        }

                        Thread.Sleep(10);

                        connection1.DoEvents();
                        connection2.DoEvents();
                    }
                }

                foreach (var bufferSize in caseList)
                {
                    var buffer1 = new byte[bufferSize];
                    var buffer2 = new byte[bufferSize];

                    random.NextBytes(buffer1);

                    var valueTask1 = connection1.SendAsync((bufferWriter) =>
                    {
                        bufferWriter.Write(buffer1);
                    });

                    var valueTask2 = connection2.ReceiveAsync((sequence) =>
                    {
                        sequence.CopyTo(buffer2);
                    });

                    var stopwatch = Stopwatch.StartNew();

                    while (!valueTask1.IsCompleted || !valueTask2.IsCompleted)
                    {
                        if (stopwatch.Elapsed.TotalSeconds > 60)
                        {
                            throw new TimeoutException("SendAndReceive");
                        }

                        await Task.Delay(100);

                        connection1.DoEvents();
                        connection2.DoEvents();
                    }

                    Assert.True(BytesOperations.Equals(buffer1, (ReadOnlySpan<byte>)buffer2));
                }
            }
        }
    }
}