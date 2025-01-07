part of 'symbol_list_page.dart';

@riverpod
class SymbolListPageNotifier extends _$SymbolListPageNotifier {
  @override
  SymbolListPageState build(Iterable<Symbol> symbols) {
    return SymbolListPageState(
      symbols: symbols.toList(),
    );
  }
}
