using System.Runtime.InteropServices;
using System;
using System.Buffers;
using System.Threading.Tasks;
using Omnius.Core;
using Omnius.Core.Network.Caps;
using Omnius.Core.Network.Connections;
using Omnius.Core.RocketPack.Remoting.Tests.Internal;
using Xunit;

namespace Omnius.Core.RocketPack.Remoting
{
    public class RocketPackRpcTests
    {
        [Fact]
        public async Task FunctionTest()
        {
            var (senderSocket, receiverSocket) = SocketHelper.GetSocketPair();

            var dispacher = new BaseConnectionDispatcher(new BaseConnectionDispatcherOptions());
            using var senderConnection = new BaseConnection(new SocketCap(senderSocket), dispacher, new BaseConnectionOptions());
            using var receiverConnection = new BaseConnection(new SocketCap(receiverSocket), dispacher, new BaseConnectionOptions());

            using var senderRpc = new RocketPackRpc(senderConnection, BytesPool.Shared);
            using var receiverRpc = new RocketPackRpc(receiverConnection, BytesPool.Shared);

            var senderEventLoopTask = senderRpc.EventLoop();
            var receiverEventLoopTask = receiverRpc.EventLoop();

            var receiverAcceptTask = receiverRpc.AcceptAsync();
            var senderConnectTask = senderRpc.ConnectAsync(0);

            using var senderStream = await senderConnectTask;
            using var receiverStream = await receiverAcceptTask;

            static async ValueTask<RpcResult> square(RpcParam param) => new RpcResult(param.P1 * param.P1);
            var responceTask = receiverStream.ResponceFunctionAsync<RpcParam, RpcResult>(square);
            var result = await senderStream.RequestFunctionAsync<RpcParam, RpcResult>(new RpcParam(11));
            await responceTask;

            Assert.Equal(121, result.R1);
        }
    }
}
