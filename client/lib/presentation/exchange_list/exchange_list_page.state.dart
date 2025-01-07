part of 'exchange_list_page.dart';

@freezed
class ExchangeListPageState with _$ExchangeListPageState {
  const factory ExchangeListPageState({
    @Default([]) List<ExchangePlace> exchanges,
  }) = _ExchangeListPageState;
}
