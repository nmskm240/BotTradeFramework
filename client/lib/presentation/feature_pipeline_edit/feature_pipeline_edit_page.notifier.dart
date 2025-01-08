part of 'feature_pipeline_edit_page.dart';

@riverpod
class FeaturePipelineEditPageNotifier
    extends _$FeaturePipelineEditPageNotifier {
  FeaturePipelineEditPageState build({
    Iterable<FeaturePipelineOrder> pipelines = const [],
  }) {
    return FeaturePipelineEditPageState(
      pipelines: pipelines.toList(),
    );
  }

  void onAdd() async {
    final usecase = ref.read(editFeaturePipelineUsecaseProvider);
    final edited = await usecase.selectBy();

    if (edited == null) {
      return;
    }

    state = state.copyWith(pipelines: [...state.pipelines, edited]);
  }

  void onConfirmed() async {
    final router = ref.read(routingServiceProvider);
    final booter = ref.read(botBooterProvider);
    final stream = booter.boot(
      BotOrder(
        symbol: Symbol(
          code: "BTCUSDT",
          name: "",
          place: ExchangePlace(
            name: "BTCUSDT",
            isBacktest: true,
          ),
        ),
        pipelineOrders: state.pipelines,
      ),
    );
    router.replace(
      RouteName.botDetail,
      arg: BotDetailRouteArgs("0", stream),
    );
  }

  void onReorder(int oldIndex, int newIndex) {}

  void onPopInvokedWithResult(
      bool didPop, Iterable<FeaturePipelineOrder>? result) {}

  void onTappedPipelineListTile(FeaturePipelineOrder tapped) {}
}
