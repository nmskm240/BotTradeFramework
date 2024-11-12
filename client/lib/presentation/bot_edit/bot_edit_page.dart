// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:form_builder_validators/form_builder_validators.dart';

// Project imports:
import 'package:bot_runner/presentation/bot_edit/bot_edit_page_notifier.dart';

class BotEditPage extends ConsumerWidget {
  const BotEditPage({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final provider = botEditPageNotifierProvider(null);
    final notifier = ref.read(provider.notifier);
    final state = ref.watch(provider);
    return Scaffold(
      body: SingleChildScrollView(
        child: FormBuilder(
          key: state.formKey,
          child: Column(
            children: [
              FormBuilderDropdown<String>(
                name: "Place",
                initialValue: state.setting.place,
                items: const [
                  DropdownMenuItem(
                    value: "Bybit",
                    child: Text("Bybit"),
                  ),
                  DropdownMenuItem(
                    value: "Binance",
                    child: Text("Binance"),
                  ),
                ],
                validator: FormBuilderValidators.compose(
                    [FormBuilderValidators.required()]),
              ),
              FormBuilderDropdown<String>(
                name: "Symbol",
                initialValue: state.setting.symbol,
                items: const [
                  DropdownMenuItem(
                    value: "BTCUSDT",
                    child: Text("BTCUSDT"),
                  ),
                  DropdownMenuItem(
                    value: "BTC/USDT",
                    child: Text("BTC/USDT"),
                  ),
                ],
              ),
              const Divider(),
              const Text("Features pipline"),
              ListView.builder(
                itemBuilder: (context, index) {
                  final pipeline =
                      state.setting.featurePipelines.elementAt(index);
                  return ListTile(
                    title: Text(pipeline.method),
                  );
                },
                itemCount: state.setting.featurePipelines.length,
                shrinkWrap: true,
              ),
              TextButton(
                onPressed: () async => await notifier.mightAddFeaturePipline(),
                child: const Text("Add pipline"),
              )
            ],
          ),
        ),
      ),
    );
  }
}
