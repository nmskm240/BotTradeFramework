// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

// Project imports:
import 'package:bot_runner/domain/feature_pipeline_setting.dart';

part 'feature_edit_page_state.freezed.dart';

@freezed
class FeatureEditPageState with _$FeatureEditPageState {
  const factory FeatureEditPageState({
    required GlobalKey<FormBuilderState> formKey,
    required FeaturePipelineSetting setting,
  }) = _FeatureEditPageState;
}
