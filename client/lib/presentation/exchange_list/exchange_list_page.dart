// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/application/generated/exchange.pb.dart';
import 'package:bot_runner/application/services/routing_service.dart';
import 'package:bot_runner/presentation/widgets/exchange_list_tile.dart';

part 'exchange_list_page.state.dart';
part 'exchange_list_page.notifier.dart';
part 'exchange_list_page.freezed.dart';
part 'exchange_list_page.g.dart';

final class ExchangeListPage extends ConsumerWidget {
  late final ExchangeListPageNotifierProvider provider;

  ExchangeListPage({
    Iterable<ExchangePlace> exchanges = const [],
  }) {
    provider = exchangeListPageNotifierProvider(exchanges);
  }

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final state = ref.watch(provider);
    final notifier = ref.read(provider.notifier);
    return Scaffold(
      appBar: AppBar(),
      body: ListView.builder(
        itemCount: state.exchanges.length,
        itemBuilder: (context, index) {
          final exchange = state.exchanges.elementAt(index);
          return ExchangeListTile(
            place: exchange,
            onTap: () => notifier.onTap(exchange),
          );
        },
      ),
    );
  }
}
