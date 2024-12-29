part of 'bot_edit_page.dart';

@riverpod
class BotEditPageNotifier extends _$BotEditPageNotifier {
  @override
  BotEditPageState build(BotOrder? order) {
    return BotEditPageState(
      formKey: GlobalKey<FormBuilderState>(),
      order: order,
    );
  }
}
