// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'feature_pipeline_order_edit_page.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

String _$featurePipelineOrderEditPageNotifierHash() =>
    r'4ba903475b93869b1a611647938da14e189bda40';

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

abstract class _$FeaturePipelineOrderEditPageNotifier
    extends BuildlessAutoDisposeNotifier<FeaturePipelineOrderEditPageState> {
  late final GlobalKey<FormBuilderState> formKey;
  late final Iterable<FeaturePipelineParameterOrder> parameters;

  FeaturePipelineOrderEditPageState build({
    required GlobalKey<FormBuilderState> formKey,
    Iterable<FeaturePipelineParameterOrder> parameters = const [],
  });
}

/// See also [FeaturePipelineOrderEditPageNotifier].
@ProviderFor(FeaturePipelineOrderEditPageNotifier)
const featurePipelineOrderEditPageNotifierProvider =
    FeaturePipelineOrderEditPageNotifierFamily();

/// See also [FeaturePipelineOrderEditPageNotifier].
class FeaturePipelineOrderEditPageNotifierFamily
    extends Family<FeaturePipelineOrderEditPageState> {
  /// See also [FeaturePipelineOrderEditPageNotifier].
  const FeaturePipelineOrderEditPageNotifierFamily();

  /// See also [FeaturePipelineOrderEditPageNotifier].
  FeaturePipelineOrderEditPageNotifierProvider call({
    required GlobalKey<FormBuilderState> formKey,
    Iterable<FeaturePipelineParameterOrder> parameters = const [],
  }) {
    return FeaturePipelineOrderEditPageNotifierProvider(
      formKey: formKey,
      parameters: parameters,
    );
  }

  @override
  FeaturePipelineOrderEditPageNotifierProvider getProviderOverride(
    covariant FeaturePipelineOrderEditPageNotifierProvider provider,
  ) {
    return call(
      formKey: provider.formKey,
      parameters: provider.parameters,
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
  String? get name => r'featurePipelineOrderEditPageNotifierProvider';
}

/// See also [FeaturePipelineOrderEditPageNotifier].
class FeaturePipelineOrderEditPageNotifierProvider
    extends AutoDisposeNotifierProviderImpl<
        FeaturePipelineOrderEditPageNotifier,
        FeaturePipelineOrderEditPageState> {
  /// See also [FeaturePipelineOrderEditPageNotifier].
  FeaturePipelineOrderEditPageNotifierProvider({
    required GlobalKey<FormBuilderState> formKey,
    Iterable<FeaturePipelineParameterOrder> parameters = const [],
  }) : this._internal(
          () => FeaturePipelineOrderEditPageNotifier()
            ..formKey = formKey
            ..parameters = parameters,
          from: featurePipelineOrderEditPageNotifierProvider,
          name: r'featurePipelineOrderEditPageNotifierProvider',
          debugGetCreateSourceHash:
              const bool.fromEnvironment('dart.vm.product')
                  ? null
                  : _$featurePipelineOrderEditPageNotifierHash,
          dependencies:
              FeaturePipelineOrderEditPageNotifierFamily._dependencies,
          allTransitiveDependencies: FeaturePipelineOrderEditPageNotifierFamily
              ._allTransitiveDependencies,
          formKey: formKey,
          parameters: parameters,
        );

  FeaturePipelineOrderEditPageNotifierProvider._internal(
    super._createNotifier, {
    required super.name,
    required super.dependencies,
    required super.allTransitiveDependencies,
    required super.debugGetCreateSourceHash,
    required super.from,
    required this.formKey,
    required this.parameters,
  }) : super.internal();

  final GlobalKey<FormBuilderState> formKey;
  final Iterable<FeaturePipelineParameterOrder> parameters;

  @override
  FeaturePipelineOrderEditPageState runNotifierBuild(
    covariant FeaturePipelineOrderEditPageNotifier notifier,
  ) {
    return notifier.build(
      formKey: formKey,
      parameters: parameters,
    );
  }

  @override
  Override overrideWith(
      FeaturePipelineOrderEditPageNotifier Function() create) {
    return ProviderOverride(
      origin: this,
      override: FeaturePipelineOrderEditPageNotifierProvider._internal(
        () => create()
          ..formKey = formKey
          ..parameters = parameters,
        from: from,
        name: null,
        dependencies: null,
        allTransitiveDependencies: null,
        debugGetCreateSourceHash: null,
        formKey: formKey,
        parameters: parameters,
      ),
    );
  }

  @override
  AutoDisposeNotifierProviderElement<FeaturePipelineOrderEditPageNotifier,
      FeaturePipelineOrderEditPageState> createElement() {
    return _FeaturePipelineOrderEditPageNotifierProviderElement(this);
  }

  @override
  bool operator ==(Object other) {
    return other is FeaturePipelineOrderEditPageNotifierProvider &&
        other.formKey == formKey &&
        other.parameters == parameters;
  }

  @override
  int get hashCode {
    var hash = _SystemHash.combine(0, runtimeType.hashCode);
    hash = _SystemHash.combine(hash, formKey.hashCode);
    hash = _SystemHash.combine(hash, parameters.hashCode);

    return _SystemHash.finish(hash);
  }
}

@Deprecated('Will be removed in 3.0. Use Ref instead')
// ignore: unused_element
mixin FeaturePipelineOrderEditPageNotifierRef
    on AutoDisposeNotifierProviderRef<FeaturePipelineOrderEditPageState> {
  /// The parameter `formKey` of this provider.
  GlobalKey<FormBuilderState> get formKey;

  /// The parameter `parameters` of this provider.
  Iterable<FeaturePipelineParameterOrder> get parameters;
}

class _FeaturePipelineOrderEditPageNotifierProviderElement
    extends AutoDisposeNotifierProviderElement<
        FeaturePipelineOrderEditPageNotifier, FeaturePipelineOrderEditPageState>
    with FeaturePipelineOrderEditPageNotifierRef {
  _FeaturePipelineOrderEditPageNotifierProviderElement(super.provider);

  @override
  GlobalKey<FormBuilderState> get formKey =>
      (origin as FeaturePipelineOrderEditPageNotifierProvider).formKey;
  @override
  Iterable<FeaturePipelineParameterOrder> get parameters =>
      (origin as FeaturePipelineOrderEditPageNotifierProvider).parameters;
}
// ignore_for_file: type=lint
// ignore_for_file: subtype_of_sealed_class, invalid_use_of_internal_member, invalid_use_of_visible_for_testing_member, deprecated_member_use_from_same_package
