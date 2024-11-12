// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:form_builder_validators/form_builder_validators.dart';

// Project imports:
import 'package:bot_runner/presentation/feature_edit/feature_edit_page_notifier.dart';

class FeatureEditPage extends ConsumerWidget {
  const FeatureEditPage({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final state = ref.watch(featureEditPageNotifierProvider);
    final notifier = ref.read(featureEditPageNotifierProvider.notifier);
    return Scaffold(
      appBar: AppBar(
        actions: [
          IconButton(
            onPressed: () {},
            icon: const Icon(Icons.check),
          ),
        ],
      ),
      body: SingleChildScrollView(
        child: FormBuilder(
          key: state.formKey,
          child: Column(
            children: [
              const Text("Buffer size"),
              const Divider(),
              FormBuilderTextField(
                name: "buffer_size",
                initialValue: state.setting.bufferSize.toString(),
                validator: FormBuilderValidators.compose(
                  [
                    FormBuilderValidators.positiveNumber(),
                  ],
                ),
              ),
              const Text("Target columns"),
              const Divider(),
              Column(
                children: [
                  ..._createTargetColumnsTextField(state.setting.targetColumns),
                  TextButton(
                    onPressed: notifier.addTargetColumn,
                    child: const Text("Add target"),
                  )
                ],
              ),
              const Text("Values"),
              const Divider(),
              Column(
                children: [
                  ..._createValuesTextField(state.setting.values),
                  TextButton(
                    onPressed: notifier.addValue,
                    child: const Text("Add value"),
                  )
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }

  Iterable<FormBuilderTextField> _createTargetColumnsTextField(
      List<String> currentTargetColumns) {
    return currentTargetColumns.indexed.map((pair) {
      return FormBuilderTextField(
        name: "Target_${pair.$1}",
        initialValue: pair.$2,
      );
    });
  }

  Iterable<FormBuilderTextField> _createValuesTextField(
      List<String> currentValues) {
    return currentValues.indexed.map((pair) {
      return FormBuilderTextField(
        name: "Value_${pair.$1}",
      );
    });
  }
}
