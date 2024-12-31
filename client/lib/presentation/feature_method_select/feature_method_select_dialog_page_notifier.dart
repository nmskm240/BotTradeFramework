// Package imports:
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/application/services/routing_service.dart';

part 'feature_method_select_dialog_page_notifier.g.dart';

@riverpod
class FeatureMethodSelectDialogPageNotifier
    extends _$FeatureMethodSelectDialogPageNotifier {
  @override
  String build() {
    return "";
  }

  void update(String value) {
    state = value;
  }

  void onConfirmed() {
    ref.read(routingServiceProvider).pop(res: state);
  }

  void onCanceled() {
    ref.read(routingServiceProvider).pop();
  }
}
