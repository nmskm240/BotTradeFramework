// Package imports:
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/application/services/routing_service.dart';

part 'home_page_notifier.g.dart';

@riverpod
class HomePageNotifier extends _$HomePageNotifier {
  @override
  void build() {
    return;
  }

  void pushBotCreatePage() {
    ref.read(routingServiceProvider).push(RouteName.botCreate);
  }
}
