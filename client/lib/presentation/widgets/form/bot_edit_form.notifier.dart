part of 'bot_edit_form.dart';

@riverpod
class BotEditFormNotifier extends _$BotEditFormNotifier {
  @override
  Future<BotEditFormState> build(GlobalKey<FormBuilderState> formKey) async {
    final overlay = ref.read(loadingOverlayServiceProvider.notifier);
    final fetcher = ref.read(exchangePlaceFetcherProvider);
    final exchanges = await overlay.wait(() => fetcher.fetch());
    return BotEditFormState(
      formKey: formKey,
      selectablePlaces: exchanges.toList(),
    );
  }

  void onChangedExchange(ExchangePlace? place) async {
    if (place == null) {
      return;
    }

    final overlay = ref.read(loadingOverlayServiceProvider.notifier);
    final fetcher = ref.read(symbolFetcherProvider);
    final symbols = await overlay.wait(() => fetcher.fetch(place));

    state = AsyncValue.data(
      state.requireValue.copyWith(selectableSymbols: symbols.toList()),
    );
  }
}
