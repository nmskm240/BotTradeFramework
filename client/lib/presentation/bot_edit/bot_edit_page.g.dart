// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'bot_edit_page.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

String _$botEditPageNotifierHash() =>
    r'08160f180f0d20a252816676353b9140f368448b';

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
  late final BotOrder? order;

  BotEditPageState build(
    BotOrder? order,
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
    BotOrder? order,
  ) {
    return BotEditPageNotifierProvider(
      order,
    );
  }

  @override
  BotEditPageNotifierProvider getProviderOverride(
    covariant BotEditPageNotifierProvider provider,
  ) {
    return call(
      provider.order,
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
    BotOrder? order,
  ) : this._internal(
          () => BotEditPageNotifier()..order = order,
          from: botEditPageNotifierProvider,
          name: r'botEditPageNotifierProvider',
          debugGetCreateSourceHash:
              const bool.fromEnvironment('dart.vm.product')
                  ? null
                  : _$botEditPageNotifierHash,
          dependencies: BotEditPageNotifierFamily._dependencies,
          allTransitiveDependencies:
              BotEditPageNotifierFamily._allTransitiveDependencies,
          order: order,
        );

  BotEditPageNotifierProvider._internal(
    super._createNotifier, {
    required super.name,
    required super.dependencies,
    required super.allTransitiveDependencies,
    required super.debugGetCreateSourceHash,
    required super.from,
    required this.order,
  }) : super.internal();

  final BotOrder? order;

  @override
  BotEditPageState runNotifierBuild(
    covariant BotEditPageNotifier notifier,
  ) {
    return notifier.build(
      order,
    );
  }

  @override
  Override overrideWith(BotEditPageNotifier Function() create) {
    return ProviderOverride(
      origin: this,
      override: BotEditPageNotifierProvider._internal(
        () => create()..order = order,
        from: from,
        name: null,
        dependencies: null,
        allTransitiveDependencies: null,
        debugGetCreateSourceHash: null,
        order: order,
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
    return other is BotEditPageNotifierProvider && other.order == order;
  }

  @override
  int get hashCode {
    var hash = _SystemHash.combine(0, runtimeType.hashCode);
    hash = _SystemHash.combine(hash, order.hashCode);

    return _SystemHash.finish(hash);
  }
}

@Deprecated('Will be removed in 3.0. Use Ref instead')
// ignore: unused_element
mixin BotEditPageNotifierRef
    on AutoDisposeNotifierProviderRef<BotEditPageState> {
  /// The parameter `order` of this provider.
  BotOrder? get order;
}

class _BotEditPageNotifierProviderElement
    extends AutoDisposeNotifierProviderElement<BotEditPageNotifier,
        BotEditPageState> with BotEditPageNotifierRef {
  _BotEditPageNotifierProviderElement(super.provider);

  @override
  BotOrder? get order => (origin as BotEditPageNotifierProvider).order;
}
// ignore_for_file: type=lint
// ignore_for_file: subtype_of_sealed_class, invalid_use_of_internal_member, invalid_use_of_visible_for_testing_member, deprecated_member_use_from_same_package
