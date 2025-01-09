// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'exchange_list_page.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

String _$exchangeListPageNotifierHash() =>
    r'a70c03b5e88e1bd47f5c6524ba03152f1b034d60';

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

abstract class _$ExchangeListPageNotifier
    extends BuildlessAutoDisposeNotifier<ExchangeListPageState> {
  late final Iterable<ExchangePlace> exchanges;

  ExchangeListPageState build(
    Iterable<ExchangePlace> exchanges,
  );
}

/// See also [ExchangeListPageNotifier].
@ProviderFor(ExchangeListPageNotifier)
const exchangeListPageNotifierProvider = ExchangeListPageNotifierFamily();

/// See also [ExchangeListPageNotifier].
class ExchangeListPageNotifierFamily extends Family<ExchangeListPageState> {
  /// See also [ExchangeListPageNotifier].
  const ExchangeListPageNotifierFamily();

  /// See also [ExchangeListPageNotifier].
  ExchangeListPageNotifierProvider call(
    Iterable<ExchangePlace> exchanges,
  ) {
    return ExchangeListPageNotifierProvider(
      exchanges,
    );
  }

  @override
  ExchangeListPageNotifierProvider getProviderOverride(
    covariant ExchangeListPageNotifierProvider provider,
  ) {
    return call(
      provider.exchanges,
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
  String? get name => r'exchangeListPageNotifierProvider';
}

/// See also [ExchangeListPageNotifier].
class ExchangeListPageNotifierProvider extends AutoDisposeNotifierProviderImpl<
    ExchangeListPageNotifier, ExchangeListPageState> {
  /// See also [ExchangeListPageNotifier].
  ExchangeListPageNotifierProvider(
    Iterable<ExchangePlace> exchanges,
  ) : this._internal(
          () => ExchangeListPageNotifier()..exchanges = exchanges,
          from: exchangeListPageNotifierProvider,
          name: r'exchangeListPageNotifierProvider',
          debugGetCreateSourceHash:
              const bool.fromEnvironment('dart.vm.product')
                  ? null
                  : _$exchangeListPageNotifierHash,
          dependencies: ExchangeListPageNotifierFamily._dependencies,
          allTransitiveDependencies:
              ExchangeListPageNotifierFamily._allTransitiveDependencies,
          exchanges: exchanges,
        );

  ExchangeListPageNotifierProvider._internal(
    super._createNotifier, {
    required super.name,
    required super.dependencies,
    required super.allTransitiveDependencies,
    required super.debugGetCreateSourceHash,
    required super.from,
    required this.exchanges,
  }) : super.internal();

  final Iterable<ExchangePlace> exchanges;

  @override
  ExchangeListPageState runNotifierBuild(
    covariant ExchangeListPageNotifier notifier,
  ) {
    return notifier.build(
      exchanges,
    );
  }

  @override
  Override overrideWith(ExchangeListPageNotifier Function() create) {
    return ProviderOverride(
      origin: this,
      override: ExchangeListPageNotifierProvider._internal(
        () => create()..exchanges = exchanges,
        from: from,
        name: null,
        dependencies: null,
        allTransitiveDependencies: null,
        debugGetCreateSourceHash: null,
        exchanges: exchanges,
      ),
    );
  }

  @override
  AutoDisposeNotifierProviderElement<ExchangeListPageNotifier,
      ExchangeListPageState> createElement() {
    return _ExchangeListPageNotifierProviderElement(this);
  }

  @override
  bool operator ==(Object other) {
    return other is ExchangeListPageNotifierProvider &&
        other.exchanges == exchanges;
  }

  @override
  int get hashCode {
    var hash = _SystemHash.combine(0, runtimeType.hashCode);
    hash = _SystemHash.combine(hash, exchanges.hashCode);

    return _SystemHash.finish(hash);
  }
}

@Deprecated('Will be removed in 3.0. Use Ref instead')
// ignore: unused_element
mixin ExchangeListPageNotifierRef
    on AutoDisposeNotifierProviderRef<ExchangeListPageState> {
  /// The parameter `exchanges` of this provider.
  Iterable<ExchangePlace> get exchanges;
}

class _ExchangeListPageNotifierProviderElement
    extends AutoDisposeNotifierProviderElement<ExchangeListPageNotifier,
        ExchangeListPageState> with ExchangeListPageNotifierRef {
  _ExchangeListPageNotifierProviderElement(super.provider);

  @override
  Iterable<ExchangePlace> get exchanges =>
      (origin as ExchangeListPageNotifierProvider).exchanges;
}
// ignore_for_file: type=lint
// ignore_for_file: subtype_of_sealed_class, invalid_use_of_internal_member, invalid_use_of_visible_for_testing_member, deprecated_member_use_from_same_package
