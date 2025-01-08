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

  void onReorder(int oldIndex, int newIndex) {
    final reordered = state.pipelines.toList();
    final e = reordered.removeAt(oldIndex);
    reordered.insert(newIndex, e);

    state = state.copyWith(pipelines: reordered);
  }

  void onPopInvokedWithResult(
      bool didPop, Iterable<FeaturePipelineOrder>? result) {}

  void onTappedPipelineListTile(int index) async {
    final usecase = ref.read(editFeaturePipelineUsecaseProvider);
    final current = state.pipelines.elementAt(index);
    final edited = await usecase.edit(current);

    if (edited == null) {
      return;
    }

    final fixed = state.pipelines.toList();
    fixed[index] = edited;

    state = state.copyWith(pipelines: fixed);
  }
}
