// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';

final class BotEditForm extends StatelessWidget {
  final GlobalKey<FormBuilderState> formKey;

  const BotEditForm({
    required this.formKey,
  });

  @override
  Widget build(BuildContext context) {
    return FormBuilder(
      key: formKey,
      child: Column(
        children: [
          // TODO
          Placeholder(
            child: Text("symbol field"),
          ),
          Divider(),
          Placeholder(
            child: Text("feature pipelines"),
          ),
        ],
      ),
    );
  }
}
