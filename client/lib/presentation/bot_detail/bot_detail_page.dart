// Dart imports:
import 'dart:async';

// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/application/generated/bot.pb.dart';
import 'package:bot_runner/application/services/loading_overlay_service.dart';
import 'package:bot_runner/presentation/widgets/bot_activity_chart.dart';

part 'bot_detail_page.state.dart';
part 'bot_detail_page.notifier.dart';
part 'bot_detail_page.g.dart';
part 'bot_detail_page.freezed.dart';

final class BotDeatilPage extends ConsumerWidget {
  late final BotDetailPageNotifierProvider _provider;

  BotDeatilPage({
    super.key,
    required Stream<BotPerformance> activities,
  }) {
    _provider = BotDetailPageNotifierProvider(activities);
  }

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final notifer = ref.read(_provider.notifier);
    final state = ref.watch(_provider);
    return Scaffold(
      appBar: AppBar(),
      body: BotActivityChart(
        performances: state.activities,
      ),
    );
  }
}
