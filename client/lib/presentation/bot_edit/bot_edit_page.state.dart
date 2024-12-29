part of 'bot_edit_page.dart';

@freezed
class BotEditPageState with _$BotEditPageState {
  const factory BotEditPageState({
    required GlobalKey<FormBuilderState> formKey,
    @Default(null) BotOrder? order,
  }) = _BotEditPageState;
}
