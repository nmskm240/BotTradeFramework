part of 'feature_pipeline_order_edit_page.dart';

@riverpod
class FeaturePipelineOrderEditPageNotifier
    extends _$FeaturePipelineOrderEditPageNotifier {
  @override
  FeaturePipelineOrderEditPageState build({
    required GlobalKey<FormBuilderState> formKey,
    Iterable<FeaturePipelineParameterOrder> parameters = const [],
  }) {
    return FeaturePipelineOrderEditPageState(
      formKey: formKey,
      parameters: parameters.toList(),
    );
  }

  void onConfirmed() {
    final formState = state.formKey.currentState;
    if (formState == null || !formState.validate()) {
      return;
    }
    formState.save();

    final router = ref.read(routingServiceProvider);
    final res = formState.value.values
        .map((e) => e as FeaturePipelineParameterOrder)
        .toList();
    router.pop(res: res);
  }
}
