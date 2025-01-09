// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:search_choices/search_choices.dart';

// Project imports:
import 'package:bot_runner/application/generated/exchange.pb.dart';
import 'package:bot_runner/presentation/widgets/exchange_list_tile.dart';

final class ExchangePlaceFormField extends FormBuilderField<ExchangePlace> {
  ExchangePlaceFormField({
    required super.name,
    required Iterable<ExchangePlace>? places,
    super.initialValue,
    super.onChanged,
  }) : super(
          builder: (field) {
            final items = (places ?? []).map((e) {
              return DropdownMenuItem<ExchangePlace>(
                value: e,
                child: ExchangeListTile(
                  place: e,
                ),
              );
            }).toList();
            return SearchChoices<ExchangePlace>.single(
              items: items,
              value: field.value,
              isExpanded: true,
              displayClearIcon: false,
              label: Text("Exchange"),
              onChanged: (e) {
                field.didChange(e);
              },
            );
          },
        );
}
