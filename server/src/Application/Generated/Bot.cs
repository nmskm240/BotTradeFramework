// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: bot.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace BotTrade.Application.Grpc.Generated {

  /// <summary>Holder for reflection information generated from bot.proto</summary>
  public static partial class BotReflection {

    #region Descriptor
    /// <summary>File descriptor for bot.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static BotReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cglib3QucHJvdG8SA2JvdBobZ29vZ2xlL3Byb3RvYnVmL2VtcHR5LnByb3Rv",
            "Gh9nb29nbGUvcHJvdG9idWYvdGltZXN0YW1wLnByb3RvGg5leGNoYW5nZS5w",
            "cm90byK8AQoTRmVhdHVyZVBpcGxpbmVPcmRlchIMCgRraW5kGAEgASgJEhcK",
            "CmJ1ZmZlclNpemUYAiABKAVIAIgBARI8CgpwYXJhbWV0ZXJzGAMgAygLMigu",
            "Ym90LkZlYXR1cmVQaXBsaW5lT3JkZXIuUGFyYW1ldGVyc0VudHJ5GjEKD1Bh",
            "cmFtZXRlcnNFbnRyeRILCgNrZXkYASABKAkSDQoFdmFsdWUYAiABKAk6AjgB",
            "Qg0KC19idWZmZXJTaXplItIBCghCb3RPcmRlchIgCgZzeW1ib2wYASABKAsy",
            "EC5leGNoYW5nZS5TeW1ib2wSKAoGb3JkZXJzGAIgAygLMhguYm90LkZlYXR1",
            "cmVQaXBsaW5lT3JkZXISMQoIc3RhcnRfYXQYAyABKAsyGi5nb29nbGUucHJv",
            "dG9idWYuVGltZXN0YW1wSACIAQESLwoGZW5kX2F0GAQgASgLMhouZ29vZ2xl",
            "LnByb3RvYnVmLlRpbWVzdGFtcEgBiAEBQgsKCV9zdGFydF9hdEIJCgdfZW5k",
            "X2F0MjoKCkJvdFNlcnZpY2USLAoDUnVuEg0uYm90LkJvdE9yZGVyGhYuZ29v",
            "Z2xlLnByb3RvYnVmLkVtcHR5QiaqAiNCb3RUcmFkZS5BcHBsaWNhdGlvbi5H",
            "cnBjLkdlbmVyYXRlZGIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, global::BotTrade.Application.Grpc.Generated.ExchangeReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::BotTrade.Application.Grpc.Generated.FeaturePiplineOrder), global::BotTrade.Application.Grpc.Generated.FeaturePiplineOrder.Parser, new[]{ "Kind", "BufferSize", "Parameters" }, new[]{ "BufferSize" }, null, null, new pbr::GeneratedClrTypeInfo[] { null, }),
            new pbr::GeneratedClrTypeInfo(typeof(global::BotTrade.Application.Grpc.Generated.BotOrder), global::BotTrade.Application.Grpc.Generated.BotOrder.Parser, new[]{ "Symbol", "Orders", "StartAt", "EndAt" }, new[]{ "StartAt", "EndAt" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class FeaturePiplineOrder : pb::IMessage<FeaturePiplineOrder>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<FeaturePiplineOrder> _parser = new pb::MessageParser<FeaturePiplineOrder>(() => new FeaturePiplineOrder());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<FeaturePiplineOrder> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::BotTrade.Application.Grpc.Generated.BotReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FeaturePiplineOrder() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FeaturePiplineOrder(FeaturePiplineOrder other) : this() {
      _hasBits0 = other._hasBits0;
      kind_ = other.kind_;
      bufferSize_ = other.bufferSize_;
      parameters_ = other.parameters_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FeaturePiplineOrder Clone() {
      return new FeaturePiplineOrder(this);
    }

    /// <summary>Field number for the "kind" field.</summary>
    public const int KindFieldNumber = 1;
    private string kind_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Kind {
      get { return kind_; }
      set {
        kind_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "bufferSize" field.</summary>
    public const int BufferSizeFieldNumber = 2;
    private readonly static int BufferSizeDefaultValue = 0;

    private int bufferSize_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int BufferSize {
      get { if ((_hasBits0 & 1) != 0) { return bufferSize_; } else { return BufferSizeDefaultValue; } }
      set {
        _hasBits0 |= 1;
        bufferSize_ = value;
      }
    }
    /// <summary>Gets whether the "bufferSize" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasBufferSize {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "bufferSize" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearBufferSize() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "parameters" field.</summary>
    public const int ParametersFieldNumber = 3;
    private static readonly pbc::MapField<string, string>.Codec _map_parameters_codec
        = new pbc::MapField<string, string>.Codec(pb::FieldCodec.ForString(10, ""), pb::FieldCodec.ForString(18, ""), 26);
    private readonly pbc::MapField<string, string> parameters_ = new pbc::MapField<string, string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::MapField<string, string> Parameters {
      get { return parameters_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as FeaturePiplineOrder);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(FeaturePiplineOrder other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Kind != other.Kind) return false;
      if (BufferSize != other.BufferSize) return false;
      if (!Parameters.Equals(other.Parameters)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Kind.Length != 0) hash ^= Kind.GetHashCode();
      if (HasBufferSize) hash ^= BufferSize.GetHashCode();
      hash ^= Parameters.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Kind.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Kind);
      }
      if (HasBufferSize) {
        output.WriteRawTag(16);
        output.WriteInt32(BufferSize);
      }
      parameters_.WriteTo(output, _map_parameters_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Kind.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Kind);
      }
      if (HasBufferSize) {
        output.WriteRawTag(16);
        output.WriteInt32(BufferSize);
      }
      parameters_.WriteTo(ref output, _map_parameters_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Kind.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Kind);
      }
      if (HasBufferSize) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(BufferSize);
      }
      size += parameters_.CalculateSize(_map_parameters_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(FeaturePiplineOrder other) {
      if (other == null) {
        return;
      }
      if (other.Kind.Length != 0) {
        Kind = other.Kind;
      }
      if (other.HasBufferSize) {
        BufferSize = other.BufferSize;
      }
      parameters_.MergeFrom(other.parameters_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Kind = input.ReadString();
            break;
          }
          case 16: {
            BufferSize = input.ReadInt32();
            break;
          }
          case 26: {
            parameters_.AddEntriesFrom(input, _map_parameters_codec);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Kind = input.ReadString();
            break;
          }
          case 16: {
            BufferSize = input.ReadInt32();
            break;
          }
          case 26: {
            parameters_.AddEntriesFrom(ref input, _map_parameters_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class BotOrder : pb::IMessage<BotOrder>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<BotOrder> _parser = new pb::MessageParser<BotOrder>(() => new BotOrder());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<BotOrder> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::BotTrade.Application.Grpc.Generated.BotReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public BotOrder() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public BotOrder(BotOrder other) : this() {
      symbol_ = other.symbol_ != null ? other.symbol_.Clone() : null;
      orders_ = other.orders_.Clone();
      startAt_ = other.startAt_ != null ? other.startAt_.Clone() : null;
      endAt_ = other.endAt_ != null ? other.endAt_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public BotOrder Clone() {
      return new BotOrder(this);
    }

    /// <summary>Field number for the "symbol" field.</summary>
    public const int SymbolFieldNumber = 1;
    private global::BotTrade.Application.Grpc.Generated.Symbol symbol_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::BotTrade.Application.Grpc.Generated.Symbol Symbol {
      get { return symbol_; }
      set {
        symbol_ = value;
      }
    }

    /// <summary>Field number for the "orders" field.</summary>
    public const int OrdersFieldNumber = 2;
    private static readonly pb::FieldCodec<global::BotTrade.Application.Grpc.Generated.FeaturePiplineOrder> _repeated_orders_codec
        = pb::FieldCodec.ForMessage(18, global::BotTrade.Application.Grpc.Generated.FeaturePiplineOrder.Parser);
    private readonly pbc::RepeatedField<global::BotTrade.Application.Grpc.Generated.FeaturePiplineOrder> orders_ = new pbc::RepeatedField<global::BotTrade.Application.Grpc.Generated.FeaturePiplineOrder>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::BotTrade.Application.Grpc.Generated.FeaturePiplineOrder> Orders {
      get { return orders_; }
    }

    /// <summary>Field number for the "start_at" field.</summary>
    public const int StartAtFieldNumber = 3;
    private global::Google.Protobuf.WellKnownTypes.Timestamp startAt_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.Timestamp StartAt {
      get { return startAt_; }
      set {
        startAt_ = value;
      }
    }

    /// <summary>Field number for the "end_at" field.</summary>
    public const int EndAtFieldNumber = 4;
    private global::Google.Protobuf.WellKnownTypes.Timestamp endAt_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.Timestamp EndAt {
      get { return endAt_; }
      set {
        endAt_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as BotOrder);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(BotOrder other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Symbol, other.Symbol)) return false;
      if(!orders_.Equals(other.orders_)) return false;
      if (!object.Equals(StartAt, other.StartAt)) return false;
      if (!object.Equals(EndAt, other.EndAt)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (symbol_ != null) hash ^= Symbol.GetHashCode();
      hash ^= orders_.GetHashCode();
      if (startAt_ != null) hash ^= StartAt.GetHashCode();
      if (endAt_ != null) hash ^= EndAt.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (symbol_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Symbol);
      }
      orders_.WriteTo(output, _repeated_orders_codec);
      if (startAt_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(StartAt);
      }
      if (endAt_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(EndAt);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (symbol_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Symbol);
      }
      orders_.WriteTo(ref output, _repeated_orders_codec);
      if (startAt_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(StartAt);
      }
      if (endAt_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(EndAt);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (symbol_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Symbol);
      }
      size += orders_.CalculateSize(_repeated_orders_codec);
      if (startAt_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(StartAt);
      }
      if (endAt_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(EndAt);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(BotOrder other) {
      if (other == null) {
        return;
      }
      if (other.symbol_ != null) {
        if (symbol_ == null) {
          Symbol = new global::BotTrade.Application.Grpc.Generated.Symbol();
        }
        Symbol.MergeFrom(other.Symbol);
      }
      orders_.Add(other.orders_);
      if (other.startAt_ != null) {
        if (startAt_ == null) {
          StartAt = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        StartAt.MergeFrom(other.StartAt);
      }
      if (other.endAt_ != null) {
        if (endAt_ == null) {
          EndAt = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        EndAt.MergeFrom(other.EndAt);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (symbol_ == null) {
              Symbol = new global::BotTrade.Application.Grpc.Generated.Symbol();
            }
            input.ReadMessage(Symbol);
            break;
          }
          case 18: {
            orders_.AddEntriesFrom(input, _repeated_orders_codec);
            break;
          }
          case 26: {
            if (startAt_ == null) {
              StartAt = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(StartAt);
            break;
          }
          case 34: {
            if (endAt_ == null) {
              EndAt = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(EndAt);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            if (symbol_ == null) {
              Symbol = new global::BotTrade.Application.Grpc.Generated.Symbol();
            }
            input.ReadMessage(Symbol);
            break;
          }
          case 18: {
            orders_.AddEntriesFrom(ref input, _repeated_orders_codec);
            break;
          }
          case 26: {
            if (startAt_ == null) {
              StartAt = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(StartAt);
            break;
          }
          case 34: {
            if (endAt_ == null) {
              EndAt = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(EndAt);
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
