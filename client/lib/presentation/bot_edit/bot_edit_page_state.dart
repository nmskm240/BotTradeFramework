// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

// Project imports:
import 'package:bot_runner/domain/bot_setting.dart';

part 'bot_edit_page_state.freezed.dart';

@freezed
class BotEditPageState with _$BotEditPageState {
  const factory BotEditPageState({
    required GlobalKey<FormBuilderState> formKey,
    required BotSetting setting,
  }) = _BotEditPageState;
}
