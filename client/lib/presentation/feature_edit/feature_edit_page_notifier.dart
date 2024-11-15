// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/domain/feature_pipeline_setting.dart';
import 'package:bot_runner/presentation/feature_edit/feature_edit_page_state.dart';

part 'feature_edit_page_notifier.g.dart';

@riverpod
class FeatureEditPageNotifier extends _$FeatureEditPageNotifier {
  @override
  FeatureEditPageState build() {
    return FeatureEditPageState(
      formKey: GlobalKey<FormBuilderState>(),
      setting: const FeaturePipelineSetting(),
    );
  }

  void updateBufferSize(int value) {
    state = state.copyWith.setting(bufferSize: value);
  }

  void addTargetColumn() {
    state = state.copyWith
        .setting(targetColumns: [...state.setting.targetColumns, ""]);
  }

  void addValue() {
    state = state.copyWith
        .setting(values: [...state.setting.values, ""]);
  }
}
