// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/application/generated/bot.pb.dart';
import 'package:bot_runner/presentation/widgets/form/bot_edit_form.dart';

part 'bot_edit_page.state.dart';
part 'bot_edit_page.notifier.dart';
part 'bot_edit_page.freezed.dart';
part 'bot_edit_page.g.dart';

class BotEditPage extends ConsumerWidget {
  const BotEditPage({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final provider = botEditPageNotifierProvider(null);
    final notifier = ref.read(provider.notifier);
    final state = ref.watch(provider);
    return Scaffold(
      appBar: AppBar(

      ),
      body: SingleChildScrollView(
        child: BotEditForm(
          formKey: state.formKey,
        ),
      ),
      floatingActionButton: FloatingActionButton(
        child: Icon(Icons.start),
        onPressed: () {}, //TODO
      ),
    );
  }
}
