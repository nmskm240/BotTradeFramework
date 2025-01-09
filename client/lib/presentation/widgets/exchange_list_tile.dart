// Flutter imports:
import 'package:flutter/material.dart';

// Project imports:
import 'package:bot_runner/application/generated/exchange.pb.dart';

final class ExchangeListTile extends StatelessWidget {
  final ExchangePlace place;
  final VoidCallback? onTap;

  const ExchangeListTile({
    required this.place,
    this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    return ListTile(
      title: Text(place.name),
      onTap: onTap,
    );
  }
}
