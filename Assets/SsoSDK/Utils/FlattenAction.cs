using System;
using UnityEngine;

namespace Sso.SsoSDK {
    internal class FlattenAction {

        private Action<string> successAction;
        private Action<string> failureAction;

        FlattenAction(Action<string> successAction, Action<string> failureAction) {
            this.successAction = successAction;
            this.failureAction = failureAction;
        }

        static internal FlattenAction JsonFlatten<T>(Action<Result<T>> action) {
            var flattenAction = new FlattenAction(
                value => {
                    var result = Result<T>.Ok(JsonUtility.FromJson<T>(value));
                    action.Invoke(result);
                },
                error => {
                    var result = Result<T>.Error(JsonUtility.FromJson<Error>(error));
                    action.Invoke(result);
                }
            );
            return flattenAction;
        }

        static internal FlattenAction UnitFlatten(Action<Result<Unit>> action) {
                var flattenAction = new FlattenAction(
                _ => {
                    var result = Result<Unit>.Ok(Unit.Value);
                    action.Invoke(result);
                },
                error => {
                    var result = Result<Unit>.Error(JsonUtility.FromJson<Error>(error));
                    action.Invoke(result);
                }
            );
            return flattenAction;
        }

        internal void CallOk(string s) {
            successAction.Invoke(s);
        }

        internal void CallError(string s) {
            failureAction.Invoke(s);
        }
    }
}