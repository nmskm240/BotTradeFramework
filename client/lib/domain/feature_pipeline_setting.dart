// Package imports:
import 'package:freezed_annotation/freezed_annotation.dart';

part 'feature_pipeline_setting.freezed.dart';

@freezed
class FeaturePipelineSetting with _$FeaturePipelineSetting {
  const factory FeaturePipelineSetting({
    @Default("") String method,
    @Default([]) List<String> targetColumns,
    @Default([]) List<String> values,
    @Default(0) int bufferSize,
  }) = $FeaturePiplineSetting;
}
