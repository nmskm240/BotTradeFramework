// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_riverpod/flutter_riverpod.dart';

// Project imports:
import 'package:bot_runner/application/services/loading_overlay_service.dart';

// Project imports:

final class LoadingOverlay extends ConsumerWidget {
  final Widget child;
  final Widget? loadingWidget;

  const LoadingOverlay({
    super.key,
    required this.child,
    this.loadingWidget,
  });

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final shouldOverlay = ref.watch(loadingOverlayServiceProvider);
    return Stack(
      children: [
        AbsorbPointer(
          absorbing: shouldOverlay,
          child: child,
        ),
        Visibility(
          visible: shouldOverlay,
          child: Container(
            color: Colors.black.withOpacity(0.5),
            child: Center(
              child: loadingWidget ?? CircularProgressIndicator(),
            ),
          ),
        ),
      ],
    );
  }
}
