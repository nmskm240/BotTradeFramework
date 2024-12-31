// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:fl_chart/fl_chart.dart';
import 'package:intl/intl.dart';

// Project imports:
import 'package:bot_runner/application/generated/bot.pb.dart';

final class BotActivityChart extends StatelessWidget {
  final List<BotPerformance> performances;

  const BotActivityChart({
    required this.performances,
  });

  @override
  Widget build(BuildContext context) {
    return LineChart(
      LineChartData(
        lineBarsData: [
          LineChartBarData(
            spots: performances.map((e) {
              return FlSpot(e.timestamp.seconds.toDouble(), e.actualValue);
            }).toList(),
            isCurved: true,
            color: Colors.grey,
            dotData: FlDotData(
              show: false,
            ),
          ),
          LineChartBarData(
            spots: performances.map((e) {
              return FlSpot(e.timestamp.seconds.toDouble(), e.predictValue);
            }).toList(),
            isCurved: true,
            color: Colors.blue,
            dotData: FlDotData(
              show: false,
            ),
          ),
        ],
        titlesData: FlTitlesData(
          leftTitles: AxisTitles(
            sideTitles: SideTitles(
              showTitles: false,
            ),
          ),
          topTitles: AxisTitles(
            sideTitles: SideTitles(
              showTitles: false,
            ),
          ),
          bottomTitles: AxisTitles(
            sideTitles: SideTitles(
              showTitles: true,
              reservedSize: 32,
              getTitlesWidget: (value, meta) {
                final date =
                    DateTime.fromMillisecondsSinceEpoch(value.toInt() * 1000);
                final formated = DateFormat('MM/dd HH:mm').format(date);
                return Text(formated);
              },
              interval: 3600,
            ),
          ),
        ),
      ),
    );
  }
}
