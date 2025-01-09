part of 'bot_edit_form.dart';

@freezed
class BotEditFormState with _$BotEditFormState {
  const factory BotEditFormState({
    required GlobalKey<FormBuilderState> formKey,
    @Default([]) List<ExchangePlace> selectablePlaces,
    @Default([]) List<Symbol> selectableSymbols,
  }) = _BotEditFormState;
}
