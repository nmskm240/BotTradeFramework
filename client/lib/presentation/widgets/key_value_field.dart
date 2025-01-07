import 'package:flutter/material.dart';

final class KeyValueField extends StatelessWidget {
  final MapEntry<String, String> initialValue;
  final Iterable<String> selectableKeys;
  final Iterable<String> selectableValues;
  final ValueChanged<MapEntry<String, String>>? onChanged;

  const KeyValueField({
    super.key,
    required this.initialValue,
    this.selectableKeys = const [],
    this.selectableValues = const [],
    this.onChanged,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
          child: selectableKeys.isEmpty
              ? TextField(
                  controller: TextEditingController(text: initialValue.key),
                  onChanged: (value) {
                    _onChanged(key: value);
                  },
                )
              : DropdownButton<String>(
                  items: selectableKeys.map((e) {
                    return DropdownMenuItem<String>(
                      child: Text(e),
                      value: e,
                    );
                  }).toList(),
                  value: selectableKeys.contains(initialValue.key)
                      ? initialValue.key
                      : selectableKeys.first,
                  onChanged: (value) {
                    _onChanged(key: value);
                  },
                ),
        ),
        Expanded(
          child: selectableValues.isEmpty
              ? TextField(
                  controller: TextEditingController(
                    text: initialValue.value,
                  ),
                  onChanged: (value) {
                    _onChanged(value: value);
                  },
                )
              : DropdownButton<String>(
                  items: selectableValues.map((e) {
                    return DropdownMenuItem<String>(
                      child: Text(e),
                      value: e,
                    );
                  }).toList(),
                  value: selectableValues.contains(initialValue.value)
                      ? initialValue.value
                      : selectableValues.first,
                  onChanged: (value) {
                    _onChanged(value: value);
                  },
                ),
        ),
      ],
    );
  }

  void _onChanged({
    String? key,
    String? value,
  }) {
    final changed = MapEntry(
      key ?? initialValue.key,
      value ?? initialValue.value,
    );
    onChanged?.call(changed);
  }
}
