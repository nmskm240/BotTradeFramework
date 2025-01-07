part of 'exchange_list_page.dart';

@riverpod
class ExchangeListPageNotifier extends _$ExchangeListPageNotifier {
  @override
  ExchangeListPageState build(Iterable<ExchangePlace> exchanges) {
    return ExchangeListPageState(
      exchanges: exchanges.toList(),
    );
  }

  void onTap(ExchangePlace place) {
    final router = ref.read(routingServiceProvider);
    router.pop(res: place);
  }
}
