// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/application/generated/exchange.pb.dart';
import 'package:bot_runner/presentation/widgets/symbol_list_tile.dart';

part 'symbol_list_page.state.dart';
part 'symbol_list_page.notifier.dart';
part 'symbol_list_page.freezed.dart';
part 'symbol_list_page.g.dart';

final class SymbolListPage extends ConsumerWidget {
  late final SymbolListPageNotifierProvider provider;

  SymbolListPage({
    Iterable<Symbol> symbols = const [],
  }) {
    provider = symbolListPageNotifierProvider(symbols);
  }

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final state = ref.watch(provider);
    return Scaffold(
      appBar: AppBar(),
      body: ListView.builder(
        itemBuilder: (context, index) {
          final symbol = state.symbols.elementAt(index);
          return SymbolListTile(symbol: symbol);
        },
      ),
    );
  }
}
