// Project imports:
import 'package:bot_runner/application/generated/feature.pb.dart';

extension FeaturePipelineOrderExtension on FeaturePipelineOrder {
  static FeaturePipelineOrder from(FeaturePipelineInfo info) {
    return FeaturePipelineOrder(
      type: info.name,
      parameters: info.parameters.map((e) {
        return FeaturePipelineParameterOrder(
            name: e.name, value: e.defaultValue);
      }).toList(),
    );
  }
}
