// Package imports:
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:grpc/grpc.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/application/generated/bot.pbgrpc.dart';
import 'package:bot_runner/application/generated/exchange.pbgrpc.dart';
import 'package:bot_runner/application/generated/feature.pbgrpc.dart';

part 'grpc_client.g.dart';

@riverpod
_GrpcClient grpcClient(Ref ref) {
  final grpc = _GrpcClient();
  ref.onDispose(() => grpc.shutdown());
  return grpc;
}

final class _GrpcClient {
  late final ClientChannel _channel;

  _GrpcClient({
    String host = "localhost",
    int port = 5052,
  }) {
    _channel = ClientChannel(
      host,
      port: port,
      options: ChannelOptions(
        credentials: ChannelCredentials.insecure(),
      ),
    );
  }

  Future<void> shutdown() async {
    await _channel.shutdown();
  }

  T get<T extends Client>({CallOptions? options}) {
    return switch (T) {
      ExchangeServiceClient => ExchangeServiceClient(
          _channel,
          options: options,
        ) as T,
      BotServiceClient => BotServiceClient(
          _channel,
          options: options,
        ) as T,
      FeatureServiceClient => FeatureServiceClient(
          _channel,
          options: options,
        ) as T,
      _ => throw UnimplementedError(),
    };
  }
}
