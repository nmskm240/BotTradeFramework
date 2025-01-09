// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'bot_edit_form.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

String _$botEditFormNotifierHash() =>
    r'7b8b9bef2cff5401576fa971126969a2721a867d';

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

abstract class _$BotEditFormNotifier
    extends BuildlessAutoDisposeAsyncNotifier<BotEditFormState> {
  late final GlobalKey<FormBuilderState> formKey;

  FutureOr<BotEditFormState> build(
    GlobalKey<FormBuilderState> formKey,
  );
}

/// See also [BotEditFormNotifier].
@ProviderFor(BotEditFormNotifier)
const botEditFormNotifierProvider = BotEditFormNotifierFamily();

/// See also [BotEditFormNotifier].
class BotEditFormNotifierFamily extends Family<AsyncValue<BotEditFormState>> {
  /// See also [BotEditFormNotifier].
  const BotEditFormNotifierFamily();

  /// See also [BotEditFormNotifier].
  BotEditFormNotifierProvider call(
    GlobalKey<FormBuilderState> formKey,
  ) {
    return BotEditFormNotifierProvider(
      formKey,
    );
  }

  @override
  BotEditFormNotifierProvider getProviderOverride(
    covariant BotEditFormNotifierProvider provider,
  ) {
    return call(
      provider.formKey,
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
  String? get name => r'botEditFormNotifierProvider';
}

/// See also [BotEditFormNotifier].
class BotEditFormNotifierProvider extends AutoDisposeAsyncNotifierProviderImpl<
    BotEditFormNotifier, BotEditFormState> {
  /// See also [BotEditFormNotifier].
  BotEditFormNotifierProvider(
    GlobalKey<FormBuilderState> formKey,
  ) : this._internal(
          () => BotEditFormNotifier()..formKey = formKey,
          from: botEditFormNotifierProvider,
          name: r'botEditFormNotifierProvider',
          debugGetCreateSourceHash:
              const bool.fromEnvironment('dart.vm.product')
                  ? null
                  : _$botEditFormNotifierHash,
          dependencies: BotEditFormNotifierFamily._dependencies,
          allTransitiveDependencies:
              BotEditFormNotifierFamily._allTransitiveDependencies,
          formKey: formKey,
        );

  BotEditFormNotifierProvider._internal(
    super._createNotifier, {
    required super.name,
    required super.dependencies,
    required super.allTransitiveDependencies,
    required super.debugGetCreateSourceHash,
    required super.from,
    required this.formKey,
  }) : super.internal();

  final GlobalKey<FormBuilderState> formKey;

  @override
  FutureOr<BotEditFormState> runNotifierBuild(
    covariant BotEditFormNotifier notifier,
  ) {
    return notifier.build(
      formKey,
    );
  }

  @override
  Override overrideWith(BotEditFormNotifier Function() create) {
    return ProviderOverride(
      origin: this,
      override: BotEditFormNotifierProvider._internal(
        () => create()..formKey = formKey,
        from: from,
        name: null,
        dependencies: null,
        allTransitiveDependencies: null,
        debugGetCreateSourceHash: null,
        formKey: formKey,
      ),
    );
  }

  @override
  AutoDisposeAsyncNotifierProviderElement<BotEditFormNotifier, BotEditFormState>
      createElement() {
    return _BotEditFormNotifierProviderElement(this);
  }

  @override
  bool operator ==(Object other) {
    return other is BotEditFormNotifierProvider && other.formKey == formKey;
  }

  @override
  int get hashCode {
    var hash = _SystemHash.combine(0, runtimeType.hashCode);
    hash = _SystemHash.combine(hash, formKey.hashCode);

    return _SystemHash.finish(hash);
  }
}

@Deprecated('Will be removed in 3.0. Use Ref instead')
// ignore: unused_element
mixin BotEditFormNotifierRef
    on AutoDisposeAsyncNotifierProviderRef<BotEditFormState> {
  /// The parameter `formKey` of this provider.
  GlobalKey<FormBuilderState> get formKey;
}

class _BotEditFormNotifierProviderElement
    extends AutoDisposeAsyncNotifierProviderElement<BotEditFormNotifier,
        BotEditFormState> with BotEditFormNotifierRef {
  _BotEditFormNotifierProviderElement(super.provider);

  @override
  GlobalKey<FormBuilderState> get formKey =>
      (origin as BotEditFormNotifierProvider).formKey;
}
// ignore_for_file: type=lint
// ignore_for_file: subtype_of_sealed_class, invalid_use_of_internal_member, invalid_use_of_visible_for_testing_member, deprecated_member_use_from_same_package
