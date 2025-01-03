// Flutter imports:
import 'package:bot_runner/presentation/widgets/symbol_list_tile.dart';
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';

// Project imports:
import 'package:bot_runner/application/generated/exchange.pb.dart';
import 'package:search_choices/search_choices.dart';

final class SymbolFormField extends FormBuilderField<Symbol> {
  SymbolFormField({
    required super.name,
    required Iterable<Symbol>? symbols,
    super.initialValue,
    super.onChanged,
  }) : super(
          builder: (field) {
            final items = (symbols ?? []).map((e) {
              return DropdownMenuItem<Symbol>(
                value: e,
                child: SymbolListTile(
                  symbol: e,
                ),
              );
            }).toList();
            return SearchChoices<Symbol>.single(
              items: items,
              value: field.value,
              isExpanded: true,
              displayClearIcon: false,
              label: Text("Symbol"),
              onChanged: (e) {
                field.didChange(e);
              },
            );
          },
        );
}
