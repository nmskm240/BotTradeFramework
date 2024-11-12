// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_riverpod/flutter_riverpod.dart';

// Project imports:
import 'package:bot_runner/presentation/home/home_page_notifier.dart';

class HomePage extends ConsumerWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final notifier = ref.read(homePageNotifierProvider.notifier);
    return Scaffold(
      floatingActionButton: FloatingActionButton(
        onPressed: notifier.pushBotCreatePage,
        child: const Icon(Icons.smart_toy),
      ),
      body: const Column(
        children: [
          Placeholder(), // TODO: plot total graph
        ],
      ),
    );
  }
}
