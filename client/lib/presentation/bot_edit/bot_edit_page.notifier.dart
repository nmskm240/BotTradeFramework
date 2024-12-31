part of 'bot_edit_page.dart';

@riverpod
class BotEditPageNotifier extends _$BotEditPageNotifier {
  @override
  BotEditPageState build(BotOrder? order) {
    return BotEditPageState(
      formKey: GlobalKey<FormBuilderState>(),
      order: order,
    );
  }

  void onEditComfirm() {
    final startAt = Timestamp(
      seconds: Int64(DateTime.utc(2020).millisecondsSinceEpoch ~/ 1000),
    );
    final endAt = Timestamp(
      seconds: Int64(DateTime.utc(2024).millisecondsSinceEpoch ~/ 1000),
    );
    final usecase = ref.read(backtestUsecaseProvider);
    final order = BotOrder(
      symbol: grpc.Symbol(
        code: "BTCUSDT",
        name: "",
        place: grpc.ExchangePlace(
          name: "Bybit",
          isBacktest: true,
        ),
      ),
      startAt: startAt,
      endAt: endAt,
    );
    usecase.call(order);
  }
}
