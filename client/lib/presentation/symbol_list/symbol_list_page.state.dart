part of 'symbol_list_page.dart';

@freezed
class SymbolListPageState with _$SymbolListPageState {
  const factory SymbolListPageState({
    @Default([]) List<Symbol> symbols,
  }) = _SymbolListPageState;
}
