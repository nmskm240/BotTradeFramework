// Package imports:
import 'package:riverpod_annotation/riverpod_annotation.dart';

part 'loading_overlay_service.g.dart';

@riverpod
class LoadingOverlayService extends _$LoadingOverlayService {
  bool build() {
    return false;
  }

  Future<T> wait<T>(Future<T> Function() task) async {
    late T res;
    try {
      final results = await Future.wait<T?>([
        task(),
        Future(() {
          state = true;
          return null;
        })
      ]);
      res = results.first as T;
    } finally {
      state = false;
    }
    return res;
  }
}
