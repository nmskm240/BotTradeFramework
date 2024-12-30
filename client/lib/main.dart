// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_riverpod/flutter_riverpod.dart';

// Project imports:
import 'package:bot_runner/application/services/routing_service.dart';
import 'package:bot_runner/presentation/router.dart';

void main() {
  runApp(
    ProviderScope(
      child: App(),
      overrides: [
        routingServiceProvider.overrideWith((ref) => routes),
      ],
    ),
  );
}

class App extends ConsumerWidget {
  const App({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final router = ref.read(routingServiceProvider);
    return MaterialApp.router(
      title: 'Bot runner',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
        useMaterial3: true,
      ),
      routerConfig: router,
    );
  }
}
