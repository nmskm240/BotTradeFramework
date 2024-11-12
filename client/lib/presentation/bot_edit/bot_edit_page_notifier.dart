// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/domain/bot_setting.dart';
import 'package:bot_runner/presentation/bot_edit/bot_edit_page_state.dart';
import 'package:bot_runner/presentation/router.dart';

part 'bot_edit_page_notifier.g.dart';

@riverpod
class BotEditPageNotifier extends _$BotEditPageNotifier {
  @override
  BotEditPageState build(BotSetting? setting) {
    return BotEditPageState(
        formKey: GlobalKey<FormBuilderState>(),
        setting: setting ?? const BotSetting());
  }

  Future mightAddFeaturePipline() async {
    final router = ref.read(routerProvider);
    final method = await router.push(router.namedLocation("feature_method_select"));
    final pipelineOrder = await router.push(router.namedLocation("feature_create"));
  }
}
