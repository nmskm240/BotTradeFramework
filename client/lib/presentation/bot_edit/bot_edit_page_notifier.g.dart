// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'bot_edit_page_notifier.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

String _$botEditPageNotifierHash() =>
    r'82c3fb02ca41c735aab9c2195889d8e4c08e3480';

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

abstract class _$BotEditPageNotifier
    extends BuildlessAutoDisposeNotifier<BotEditPageState> {
  late final BotSetting? setting;

  BotEditPageState build(
    BotSetting? setting,
  );
}

/// See also [BotEditPageNotifier].
@ProviderFor(BotEditPageNotifier)
const botEditPageNotifierProvider = BotEditPageNotifierFamily();

/// See also [BotEditPageNotifier].
class BotEditPageNotifierFamily extends Family<BotEditPageState> {
  /// See also [BotEditPageNotifier].
  const BotEditPageNotifierFamily();

  /// See also [BotEditPageNotifier].
  BotEditPageNotifierProvider call(
    BotSetting? setting,
  ) {
    return BotEditPageNotifierProvider(
      setting,
    );
  }

  @override
  BotEditPageNotifierProvider getProviderOverride(
    covariant BotEditPageNotifierProvider provider,
  ) {
    return call(
      provider.setting,
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
  String? get name => r'botEditPageNotifierProvider';
}

/// See also [BotEditPageNotifier].
class BotEditPageNotifierProvider extends AutoDisposeNotifierProviderImpl<
    BotEditPageNotifier, BotEditPageState> {
  /// See also [BotEditPageNotifier].
  BotEditPageNotifierProvider(
    BotSetting? setting,
  ) : this._internal(
          () => BotEditPageNotifier()..setting = setting,
          from: botEditPageNotifierProvider,
          name: r'botEditPageNotifierProvider',
          debugGetCreateSourceHash:
              const bool.fromEnvironment('dart.vm.product')
                  ? null
                  : _$botEditPageNotifierHash,
          dependencies: BotEditPageNotifierFamily._dependencies,
          allTransitiveDependencies:
              BotEditPageNotifierFamily._allTransitiveDependencies,
          setting: setting,
        );

  BotEditPageNotifierProvider._internal(
    super._createNotifier, {
    required super.name,
    required super.dependencies,
    required super.allTransitiveDependencies,
    required super.debugGetCreateSourceHash,
    required super.from,
    required this.setting,
  }) : super.internal();

  final BotSetting? setting;

  @override
  BotEditPageState runNotifierBuild(
    covariant BotEditPageNotifier notifier,
  ) {
    return notifier.build(
      setting,
    );
  }

  @override
  Override overrideWith(BotEditPageNotifier Function() create) {
    return ProviderOverride(
      origin: this,
      override: BotEditPageNotifierProvider._internal(
        () => create()..setting = setting,
        from: from,
        name: null,
        dependencies: null,
        allTransitiveDependencies: null,
        debugGetCreateSourceHash: null,
        setting: setting,
      ),
    );
  }

  @override
  AutoDisposeNotifierProviderElement<BotEditPageNotifier, BotEditPageState>
      createElement() {
    return _BotEditPageNotifierProviderElement(this);
  }

  @override
  bool operator ==(Object other) {
    return other is BotEditPageNotifierProvider && other.setting == setting;
  }

  @override
  int get hashCode {
    var hash = _SystemHash.combine(0, runtimeType.hashCode);
    hash = _SystemHash.combine(hash, setting.hashCode);

    return _SystemHash.finish(hash);
  }
}

@Deprecated('Will be removed in 3.0. Use Ref instead')
// ignore: unused_element
mixin BotEditPageNotifierRef
    on AutoDisposeNotifierProviderRef<BotEditPageState> {
  /// The parameter `setting` of this provider.
  BotSetting? get setting;
}

class _BotEditPageNotifierProviderElement
    extends AutoDisposeNotifierProviderElement<BotEditPageNotifier,
        BotEditPageState> with BotEditPageNotifierRef {
  _BotEditPageNotifierProviderElement(super.provider);

  @override
  BotSetting? get setting => (origin as BotEditPageNotifierProvider).setting;
}
// ignore_for_file: type=lint
// ignore_for_file: subtype_of_sealed_class, invalid_use_of_internal_member, invalid_use_of_visible_for_testing_member, deprecated_member_use_from_same_package
