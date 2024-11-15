// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_riverpod/flutter_riverpod.dart';

// Project imports:
import 'package:bot_runner/presentation/feature_method_select/feature_method_select_dialog_page_notifier.dart';

class FeatureMethodSelectDialogPage extends ConsumerWidget {
  const FeatureMethodSelectDialogPage({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final notifier =
        ref.read(featureMethodSelectDialogPageNotifierProvider.notifier);
    final state = ref.watch(featureMethodSelectDialogPageNotifierProvider);
    return AlertDialog(
      title: const Text("Select pipeline method"),
      content: DropdownButton(
        value: state.isEmpty ? null : state,
        items: const [
          DropdownMenuItem(
            value: "remove",
            child: Text("remove"),
          ),
          DropdownMenuItem(
            value: "aggregate",
            child: Text("aggregate"),
          ),
          DropdownMenuItem(
            value: "ma",
            child: Text("ma"),
          ),
        ],
        onChanged: (value) => notifier.update(value!),
      ),
      actions: [
        TextButton(
          onPressed: notifier.onCanceled,
          child: const Text("Cancel"),
        ),
        TextButton(
          onPressed: notifier.onConfirmed,
          child: const Text("Ok"),
        ),
      ],
    );
  }
}
