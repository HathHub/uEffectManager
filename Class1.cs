using SDG.NetTransport;
using SDG.Unturned;
using Steamworks;
using UnityEngine;
using System;
using uScript.API.Attributes;
using uScript.Core;
using uScript.Module.Main.Classes;

[ScriptModule("uEffectManager")]
public class uEffects
{
    [ScriptFunction("sendEffect")]
    public static void SendEffect( ushort id, string playerId, Vector3Class position)
    {

        ITransportConnection transportConnection = Provider.findTransportConnection(new CSteamID(ulong.Parse(playerId)));
        EffectManager.sendEffect(id, transportConnection, position.Vector3);
    }

    [ScriptFunction("triggerEffect")]
    public static void TriggerEffect( ushort id, float range, Vector3Class position)
    {
            var asset = Assets.find(EAssetType.EFFECT, id);
            var eff = new TriggerEffectParameters((EffectAsset)asset)
            {
                relevantDistance = range,
                position = position.Vector3
            };
            EffectManager.triggerEffect(eff);
    }

    [ScriptFunction("ClearEffectByGuid")]
    public static void ClearEffectByGuid(string guid, string playerId)
    {
            ITransportConnection transportConnection = Provider.findTransportConnection(new CSteamID(ulong.Parse(playerId)));
        EffectManager.ClearEffectByGuid(Guid.Parse(guid), transportConnection);
        
    }

    [ScriptFunction("askEffectClearByID")]
    public static void askEffectClearByID( ushort id, string playerId)
    {
            ITransportConnection transportConnection = Provider.findTransportConnection(new CSteamID(ulong.Parse(playerId)));
            EffectManager.askEffectClearByID(id, transportConnection);
    }

    [ScriptFunction("ClearEffectByID_AllPlayers")]
    public static void ClearEffectByID_AllPlayers(ushort id)
    {
        EffectManager.ClearEffectByID_AllPlayers(id);
    }

    [ScriptFunction("ClearEffectByGuid_AllPlayers")]
    public static void ClearEffectByGuid_AllPlayers(string guid)
    {
        EffectManager.ClearEffectByGuid_AllPlayers(Guid.Parse(guid));
    }

    [ScriptFunction("sendEffectClicked")]
    public static void sendEffectClicked(string buttonName)
    {
        EffectManager.sendEffectClicked(buttonName);
    }

    [ScriptFunction("sendEffectTextCommitted")]
    public static void sendEffectTextCommitted(string inputFieldName, string text)
    {
        EffectManager.sendEffectTextCommitted(inputFieldName, text);
    }

    [ScriptFunction("sendEffectReliable")]
    public static void sendEffectReliable(ushort id, string playerId, Vector3Class position)
    {
        ITransportConnection transportConnection = Provider.findTransportConnection(new CSteamID(ulong.Parse(playerId)));
        EffectManager.sendEffectReliable(id, transportConnection, position.Vector3);
    }

    [ScriptFunction("sendEffectReliable_NonUniformScale")]
    public static void sendEffectReliable_NonUniformScale(ushort id, string playerId, Vector3Class position, Vector3Class scale)
    {
        ITransportConnection transportConnection = Provider.findTransportConnection(new CSteamID(ulong.Parse(playerId)));
        EffectManager.sendEffectReliable_NonUniformScale(id, transportConnection, position.Vector3, position.Vector3);
    }

    [ScriptFunction("askEffectClearAll")]
    public static void askEffectClearAll()
    {
        EffectManager.askEffectClearAll();
    }


}