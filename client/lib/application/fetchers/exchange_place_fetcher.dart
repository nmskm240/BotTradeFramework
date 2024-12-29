// Package imports:
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/application/generated/exchange.pbgrpc.dart';
import 'package:bot_runner/application/generated/google/protobuf/empty.pb.dart';
import 'package:bot_runner/infra/grpc_client.dart';

// Project imports:

part 'exchange_place_fetcher.g.dart';

@riverpod
_ExchangePlaceFetcher exchangePlaceFetcher(Ref ref) {
  final grpc = ref.read(grpcClientProvider);
  final client = grpc.get<ExchangeServiceClient>();
  return _ExchangePlaceFetcher(client: client);
}

final class _ExchangePlaceFetcher {
  final ExchangeServiceClient client;

  const _ExchangePlaceFetcher({
    required this.client,
  });

  Future<Iterable<ExchangePlace>> fetch() async {
    final res = await client.supportedExchanges(Empty());
    return res.places;
  }
}