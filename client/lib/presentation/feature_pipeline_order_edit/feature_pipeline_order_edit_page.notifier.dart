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
    if (!(state.formKey.currentState?.validate() ?? false)) {
      return;
    }
    state.formKey.currentState!.save();
    print(state.formKey.currentState!.value);
  }
}
