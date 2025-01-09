// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'feature_info_list_page.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

String _$featureInfoListPageNotifierHash() =>
    r'42934403fe3287e8923a46b7551d94cf8009708e';

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

abstract class _$FeatureInfoListPageNotifier
    extends BuildlessAutoDisposeNotifier<FeatureInfoListPageState> {
  late final Iterable<FeaturePipelineInfo> infos;

  FeatureInfoListPageState build({
    Iterable<FeaturePipelineInfo> infos = const [],
  });
}

/// See also [FeatureInfoListPageNotifier].
@ProviderFor(FeatureInfoListPageNotifier)
const featureInfoListPageNotifierProvider = FeatureInfoListPageNotifierFamily();

/// See also [FeatureInfoListPageNotifier].
class FeatureInfoListPageNotifierFamily
    extends Family<FeatureInfoListPageState> {
  /// See also [FeatureInfoListPageNotifier].
  const FeatureInfoListPageNotifierFamily();

  /// See also [FeatureInfoListPageNotifier].
  FeatureInfoListPageNotifierProvider call({
    Iterable<FeaturePipelineInfo> infos = const [],
  }) {
    return FeatureInfoListPageNotifierProvider(
      infos: infos,
    );
  }

  @override
  FeatureInfoListPageNotifierProvider getProviderOverride(
    covariant FeatureInfoListPageNotifierProvider provider,
  ) {
    return call(
      infos: provider.infos,
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
  String? get name => r'featureInfoListPageNotifierProvider';
}

/// See also [FeatureInfoListPageNotifier].
class FeatureInfoListPageNotifierProvider
    extends AutoDisposeNotifierProviderImpl<FeatureInfoListPageNotifier,
        FeatureInfoListPageState> {
  /// See also [FeatureInfoListPageNotifier].
  FeatureInfoListPageNotifierProvider({
    Iterable<FeaturePipelineInfo> infos = const [],
  }) : this._internal(
          () => FeatureInfoListPageNotifier()..infos = infos,
          from: featureInfoListPageNotifierProvider,
          name: r'featureInfoListPageNotifierProvider',
          debugGetCreateSourceHash:
              const bool.fromEnvironment('dart.vm.product')
                  ? null
                  : _$featureInfoListPageNotifierHash,
          dependencies: FeatureInfoListPageNotifierFamily._dependencies,
          allTransitiveDependencies:
              FeatureInfoListPageNotifierFamily._allTransitiveDependencies,
          infos: infos,
        );

  FeatureInfoListPageNotifierProvider._internal(
    super._createNotifier, {
    required super.name,
    required super.dependencies,
    required super.allTransitiveDependencies,
    required super.debugGetCreateSourceHash,
    required super.from,
    required this.infos,
  }) : super.internal();

  final Iterable<FeaturePipelineInfo> infos;

  @override
  FeatureInfoListPageState runNotifierBuild(
    covariant FeatureInfoListPageNotifier notifier,
  ) {
    return notifier.build(
      infos: infos,
    );
  }

  @override
  Override overrideWith(FeatureInfoListPageNotifier Function() create) {
    return ProviderOverride(
      origin: this,
      override: FeatureInfoListPageNotifierProvider._internal(
        () => create()..infos = infos,
        from: from,
        name: null,
        dependencies: null,
        allTransitiveDependencies: null,
        debugGetCreateSourceHash: null,
        infos: infos,
      ),
    );
  }

  @override
  AutoDisposeNotifierProviderElement<FeatureInfoListPageNotifier,
      FeatureInfoListPageState> createElement() {
    return _FeatureInfoListPageNotifierProviderElement(this);
  }

  @override
  bool operator ==(Object other) {
    return other is FeatureInfoListPageNotifierProvider && other.infos == infos;
  }

  @override
  int get hashCode {
    var hash = _SystemHash.combine(0, runtimeType.hashCode);
    hash = _SystemHash.combine(hash, infos.hashCode);

    return _SystemHash.finish(hash);
  }
}

@Deprecated('Will be removed in 3.0. Use Ref instead')
// ignore: unused_element
mixin FeatureInfoListPageNotifierRef
    on AutoDisposeNotifierProviderRef<FeatureInfoListPageState> {
  /// The parameter `infos` of this provider.
  Iterable<FeaturePipelineInfo> get infos;
}

class _FeatureInfoListPageNotifierProviderElement
    extends AutoDisposeNotifierProviderElement<FeatureInfoListPageNotifier,
        FeatureInfoListPageState> with FeatureInfoListPageNotifierRef {
  _FeatureInfoListPageNotifierProviderElement(super.provider);

  @override
  Iterable<FeaturePipelineInfo> get infos =>
      (origin as FeatureInfoListPageNotifierProvider).infos;
}
// ignore_for_file: type=lint
// ignore_for_file: subtype_of_sealed_class, invalid_use_of_internal_member, invalid_use_of_visible_for_testing_member, deprecated_member_use_from_same_package
