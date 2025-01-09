// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'feature_pipeline_edit_page.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

String _$featurePipelineEditPageNotifierHash() =>
    r'd64bbba3c068d20205542cdf836a319452de1a42';

/// Copied from Dart SDK
class _SystemHash {
  _SystemHash._();

  static int combine(int hash, int value) {
    // ignore: parameter_assignments
    hash = 0x1fffffff & (hash + value);
    // ignore: parameter_assignments
    hash = 0x1fffffff & (hash + ((0x0007ffff & hash) << 10));
    return hash ^ (hash >> 6);
  }

  static int finish(int hash) {
    // ignore: parameter_assignments
    hash = 0x1fffffff & (hash + ((0x03ffffff & hash) << 3));
    // ignore: parameter_assignments
    hash = hash ^ (hash >> 11);
    return 0x1fffffff & (hash + ((0x00003fff & hash) << 15));
  }
}

abstract class _$FeaturePipelineEditPageNotifier
    extends BuildlessAutoDisposeNotifier<FeaturePipelineEditPageState> {
  late final Iterable<FeaturePipelineOrder> pipelines;

  FeaturePipelineEditPageState build({
    Iterable<FeaturePipelineOrder> pipelines = const [],
  });
}

/// See also [FeaturePipelineEditPageNotifier].
@ProviderFor(FeaturePipelineEditPageNotifier)
const featurePipelineEditPageNotifierProvider =
    FeaturePipelineEditPageNotifierFamily();

/// See also [FeaturePipelineEditPageNotifier].
class FeaturePipelineEditPageNotifierFamily
    extends Family<FeaturePipelineEditPageState> {
  /// See also [FeaturePipelineEditPageNotifier].
  const FeaturePipelineEditPageNotifierFamily();

  /// See also [FeaturePipelineEditPageNotifier].
  FeaturePipelineEditPageNotifierProvider call({
    Iterable<FeaturePipelineOrder> pipelines = const [],
  }) {
    return FeaturePipelineEditPageNotifierProvider(
      pipelines: pipelines,
    );
  }

  @override
  FeaturePipelineEditPageNotifierProvider getProviderOverride(
    covariant FeaturePipelineEditPageNotifierProvider provider,
  ) {
    return call(
      pipelines: provider.pipelines,
    );
  }

  static const Iterable<ProviderOrFamily>? _dependencies = null;

  @override
  Iterable<ProviderOrFamily>? get dependencies => _dependencies;

  static const Iterable<ProviderOrFamily>? _allTransitiveDependencies = null;

  @override
  Iterable<ProviderOrFamily>? get allTransitiveDependencies =>
      _allTransitiveDependencies;

  @override
  String? get name => r'featurePipelineEditPageNotifierProvider';
}

/// See also [FeaturePipelineEditPageNotifier].
class FeaturePipelineEditPageNotifierProvider
    extends AutoDisposeNotifierProviderImpl<FeaturePipelineEditPageNotifier,
        FeaturePipelineEditPageState> {
  /// See also [FeaturePipelineEditPageNotifier].
  FeaturePipelineEditPageNotifierProvider({
    Iterable<FeaturePipelineOrder> pipelines = const [],
  }) : this._internal(
          () => FeaturePipelineEditPageNotifier()..pipelines = pipelines,
          from: featurePipelineEditPageNotifierProvider,
          name: r'featurePipelineEditPageNotifierProvider',
          debugGetCreateSourceHash:
              const bool.fromEnvironment('dart.vm.product')
                  ? null
                  : _$featurePipelineEditPageNotifierHash,
          dependencies: FeaturePipelineEditPageNotifierFamily._dependencies,
          allTransitiveDependencies:
              FeaturePipelineEditPageNotifierFamily._allTransitiveDependencies,
          pipelines: pipelines,
        );

  FeaturePipelineEditPageNotifierProvider._internal(
    super._createNotifier, {
    required super.name,
    required super.dependencies,
    required super.allTransitiveDependencies,
    required super.debugGetCreateSourceHash,
    required super.from,
    required this.pipelines,
  }) : super.internal();

  final Iterable<FeaturePipelineOrder> pipelines;

  @override
  FeaturePipelineEditPageState runNotifierBuild(
    covariant FeaturePipelineEditPageNotifier notifier,
  ) {
    return notifier.build(
      pipelines: pipelines,
    );
  }

  @override
  Override overrideWith(FeaturePipelineEditPageNotifier Function() create) {
    return ProviderOverride(
      origin: this,
      override: FeaturePipelineEditPageNotifierProvider._internal(
        () => create()..pipelines = pipelines,
        from: from,
        name: null,
        dependencies: null,
        allTransitiveDependencies: null,
        debugGetCreateSourceHash: null,
        pipelines: pipelines,
      ),
    );
  }

  @override
  AutoDisposeNotifierProviderElement<FeaturePipelineEditPageNotifier,
      FeaturePipelineEditPageState> createElement() {
    return _FeaturePipelineEditPageNotifierProviderElement(this);
  }

  @override
  bool operator ==(Object other) {
    return other is FeaturePipelineEditPageNotifierProvider &&
        other.pipelines == pipelines;
  }

  @override
  int get hashCode {
    var hash = _SystemHash.combine(0, runtimeType.hashCode);
    hash = _SystemHash.combine(hash, pipelines.hashCode);

    return _SystemHash.finish(hash);
  }
}

@Deprecated('Will be removed in 3.0. Use Ref instead')
// ignore: unused_element
mixin FeaturePipelineEditPageNotifierRef
    on AutoDisposeNotifierProviderRef<FeaturePipelineEditPageState> {
  /// The parameter `pipelines` of this provider.
  Iterable<FeaturePipelineOrder> get pipelines;
}

class _FeaturePipelineEditPageNotifierProviderElement
    extends AutoDisposeNotifierProviderElement<FeaturePipelineEditPageNotifier,
        FeaturePipelineEditPageState> with FeaturePipelineEditPageNotifierRef {
  _FeaturePipelineEditPageNotifierProviderElement(super.provider);

  @override
  Iterable<FeaturePipelineOrder> get pipelines =>
      (origin as FeaturePipelineEditPageNotifierProvider).pipelines;
}
// ignore_for_file: type=lint
// ignore_for_file: subtype_of_sealed_class, invalid_use_of_internal_member, invalid_use_of_visible_for_testing_member, deprecated_member_use_from_same_package
