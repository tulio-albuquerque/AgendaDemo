<template>
  <div id="delete" class="modal-container">
        <div class="modal">
            <section>
                <header class="modal-header">
                    <span @click="cancel">&times;</span>
                    <h2>Confirme a remoção</h2>
                </header>
                <section class="modal-content">
                    <p>Essa ação não pode ser desfeita</p>
                </section>
                <footer class="modal-footer">
                    <button class="modal-button" @click="cancel">Cancel</button>
                    <button class="modal-button modal-confirm-button" @click="remove">
                        Confirm
                    </button>
                </footer>
            </section>
        </div>
    </div>
</template>

<script>
import axios from "axios";

export default {
  name: "AddContact",
  props: ['contact'],
  methods: {
    cancel() {
      let confirmation = document.getElementById("delete");
      confirmation.classList.remove("modal-open");
    },
    remove() {
      axios.delete("/contacts/" +this.contact.id)
      this.$emit("close", "delete")
    }
  },
};
</script>

<style scoped>
.modal-container {
  z-index: 9999;
  position: fixed;
  left: 0;
  top: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: none;
  align-items: center;
  justify-content: center;
}

.modal-open {
  display: flex;
}

.modal {
  max-width: 700px;
  max-height: 700px;
  background-color: white;
  border-radius: 3px;
}

.modal-button {
  text-transform: uppercase;
  padding: 0.5em 1em;
  border: none;
  color: white;
  background-color: rgba(0, 0, 0, 0.5);
  border-radius: 3px;
  margin-left: 0.5em;
}

.modal-confirm-button {
  background-color: tomato;
}

.modal-header {
  background-color: rgba(0, 0, 0, 0.1);
  display: flex;
  flex-direction: column;
}

.modal-header h2 {
  margin: 1em;
}

.modal-header span {
  align-self: flex-end;
  padding-right: 0.3em;
  cursor: default;
}

.modal-content {
  padding: 1em;
}

.modal-footer {
  padding: 1em;
  background-color: rgba(0, 0, 0, 0.05);
  display: flex;
  justify-content: flex-end;
}

/*  */

.card__content--body {
  display: flex;
  flex-direction: column;
  gap: 20px;
  padding: 20px;
}

/* add */

.form-control label {
  display: inline-block;
  margin-bottom: 5px;
}

.form-control input {
  border: 2px solid #f0f0f0;
  border-radius: 4px;
  display: block;
  font-family: inherit;
  font-size: 14px;
  padding: 10px;
  width: 100%;
}

.form-control i {
  visibility: hidden;
  position: absolute;
  top: 40px;
  right: 10px;
}

.form-control small {
  visibility: hidden;
  position: absolute;
  bottom: 0;
  left: 0;
}
</style>