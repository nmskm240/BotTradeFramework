import 'package:bot_runner/application/generated/bot.pb.dart';
import 'package:flutter/material.dart';
import 'package:graphic/graphic.dart';

final class BotActivityChart extends Chart<BotPerformance> {
  BotActivityChart({
    required super.data,
  }) : super(
          variables: {
            "time": Variable<BotPerformance, DateTime>(
              accessor: (p0) => p0.timestamp.toDateTime(),
              scale: TimeScale(
                title: "time",
              ),
            ),
            "actual": Variable<BotPerformance, double>(
              accessor: (p0) => p0.actualValue,
            ),
            "predicate": Variable<BotPerformance, double>(
              accessor: (p0) => p0.predictValue,
            ),
          },
          marks: [
            LineMark(
                position: Varset("time") * Varset("actual"),
                color: ColorEncode(
                  value: Colors.grey,
                )),
            LineMark(
                position: Varset("time") * Varset("predicate"),
                color: ColorEncode(
                  value: Colors.blue,
                )),
          ],
          axes: [
            Defaults.verticalAxis,
            Defaults.horizontalAxis,
          ],
        );
}
