// Flutter imports:
import 'package:flutter/material.dart';

// Project imports:
import 'package:bot_runner/application/generated/exchange.pb.dart';

final class SymbolListTile extends StatelessWidget {
  final Symbol symbol;
  final VoidCallback? onTap;

  const SymbolListTile({
    required this.symbol,
    this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    return ListTile(
      title: Text(symbol.name),
      subtitle: Text(symbol.place.name),
      onTap: onTap,
    );
  }
}
